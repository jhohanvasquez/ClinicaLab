import { Component, Inject, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Usuario } from '../../../../interfaces/usuario';
import { UsuarioServicioService } from '../../../../services/usuario-servicio.service';
import { DepartamentoPacienteService } from '../../../../services/departamentopaciente.service';
import { DepartamentoPaciente } from '../../../../interfaces/departamentopaciente';

@Component({
  selector: 'app-dialog-usuario',
  templateUrl: './dialog-usuario.component.html',
  styleUrls: ['./dialog-usuario.component.css']
})
export class DialogUsuarioComponent implements OnInit, AfterViewInit {
  formUsuario: FormGroup;
  hide: boolean = true;
  accion: string = "Agregar"
  accionBoton: string = "Guardar";
  listaDepartamentoPaciente: DepartamentoPaciente[] = [];

  constructor(
    private dialogoReferencia: MatDialogRef<DialogUsuarioComponent>,
    @Inject(MAT_DIALOG_DATA) public usuarioEditar: Usuario,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private _usuarioServicio: UsuarioServicioService,
    private _DepartamentoPacienteServicio: DepartamentoPacienteService
  ) {

    this.formUsuario = this.fb.group({
      nombreApellido: ['', Validators.required],
      correo: ['', Validators.required],
      idDepartamentoPaciente: ['', Validators.required],
      clave: ['', Validators.required],
    })


    if (this.usuarioEditar) {
      this.accion = "Editar";
      this.accionBoton = "Actualizar";
    }

    this._DepartamentoPacienteServicio.getDepartamentoPacientes().subscribe({
      next: (data) => {

        if (data.status) {

          this.listaDepartamentoPaciente = data.value;

          if (this.usuarioEditar)
            this.formUsuario.patchValue({
              idDepartamentoPaciente: this.usuarioEditar.idDepartamentoPaciente
            })

        }
      },
      error: (e) => {
      },
      complete: () => {
      }
    })   

  }

  ngOnInit(): void {

    if (this.usuarioEditar) {

      this.formUsuario.patchValue({
        nombreApellido: this.usuarioEditar.nombreApellidos,
        correo: this.usuarioEditar.correo,
        idDepartamentoPaciente: this.usuarioEditar.idDepartamentoPaciente,
        clave: this.usuarioEditar.clave
      })
    }

  }

  ngAfterViewInit() {

  }


  agregarEditarUsuario() {


    const _usuario: Usuario = {
      idUsuario: this.usuarioEditar == null ? 0 : this.usuarioEditar.idUsuario,
      nombreApellidos: this.formUsuario.value.nombreApellido,
      correo: this.formUsuario.value.correo,
      idDepartamentoPaciente: this.formUsuario.value.idDepartamentoPaciente,
      descripcionDepartamento: "",
      clave: this.formUsuario.value.clave
    }


    if (this.usuarioEditar) {

      this._usuarioServicio.editUsuario(_usuario).subscribe({
        next: (data) => {

          if (data.status) {
            this.mostrarAlerta("El usuario fue editado", "Exito");
            this.dialogoReferencia.close('editado')
          } else {
            this.mostrarAlerta("No se pudo editar el usuario", "Error");
          }

        },
        error: (e) => {
          console.log(e)
        },
        complete: () => {
        }
      })


    } else {

      this._usuarioServicio.saveUsuario(_usuario).subscribe({
        next: (data) => {

          if (data.status) {
            this.mostrarAlerta("El usuario fue registrado", "Exito");
            this.dialogoReferencia.close('agregado')
          } else {
            this.mostrarAlerta("No se pudo registrar el usuario", "Error");
          }

        },
        error: (e) => {
        },
        complete: () => {
        }
      })


    }
  }

  mostrarAlerta(mensaje: string, tipo: string) {
    this._snackBar.open(mensaje, tipo, {
      horizontalPosition: "end",
      verticalPosition: "top",
      duration: 3000
    });
  }

}

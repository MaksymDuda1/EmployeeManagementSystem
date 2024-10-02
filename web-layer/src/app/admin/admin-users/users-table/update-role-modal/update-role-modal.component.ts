import { Component, EventEmitter, Input, OnChanges, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import { UserModel } from '../../../../../models/user.model';
import { Role } from '../../../../../enums/role.enum';
import { CommonModule } from '@angular/common';
import { AdminService } from '../../../../../services/admin.service';
import { ChangeRoleModel } from '../../../../../models/change-role.model';

@Component({
  selector: 'app-update-role-modal',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './update-role-modal.component.html',
  styleUrls: ['./update-role-modal.component.scss']
})
export class UpdateRoleModalComponent implements OnChanges {
  @Input() userData!: UserModel;
  roleForm: FormGroup; 
  @Output() closeModalEvent = new EventEmitter<void>();
  roles: Role[] = [Role.Admin, Role.Employee, Role.Manager];

  constructor(
    private fb: FormBuilder,
    private adminService: AdminService
  ) { 
    this.roleForm = this.fb.group({
      username: [{ value: '', disabled: true }],
      email: [{ value: '', disabled: true }],
      role: [null, Validators.required],
      position: [null], 
      department: [null] 
    });
  }

  ngOnChanges(): void {
    if (this.userData) { 
      this.roleForm.patchValue({
        username: this.userData.username,
        email: this.userData.email,
        role: this.userData.role
      });
    }
  }

  onRoleChange() {
    const role = this.roleForm.get('role')?.value;
    if (role === Role.Employee) {
      this.roleForm.get('position')?.setValidators([Validators.required]);
      this.roleForm.get('department')?.clearValidators();
    } else if (role === Role.Manager) {
      this.roleForm.get('department')?.setValidators([Validators.required]);
      this.roleForm.get('position')?.clearValidators();
    } else {
      this.roleForm.get('position')?.clearValidators();
      this.roleForm.get('department')?.clearValidators();
    }
    this.roleForm.get('position')?.updateValueAndValidity();
    this.roleForm.get('department')?.updateValueAndValidity();
  }

  onSubmit() {
    if (this.roleForm.valid) {
      const changeRoleDto = new ChangeRoleModel();
      changeRoleDto.userId = this.userData.id;
      changeRoleDto.role = this.roleForm.get('role')?.value;

      if (changeRoleDto.role === Role.Employee) {
        changeRoleDto.employee = {
          position: this.roleForm.get('position')?.value
        };
      } else if (changeRoleDto.role === Role.Manager) {
        changeRoleDto.manager = {
          department: this.roleForm.get('department')?.value
        };
      }

      this.adminService.changeUserRole(changeRoleDto).subscribe(
        () => {
          this.closeModal();
        },
        error => {
          console.error('Error changing user role:', error);
        }
      );
    }
  }

  closeModal() {
    this.closeModalEvent.emit();
  }
}

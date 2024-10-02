import { ChangeDetectionStrategy, Component, ViewChild } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule, provideNativeDateAdapter } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatAccordion, MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { FormGroup, FormBuilder, FormsModule, ReactiveFormsModule, FormControl } from '@angular/forms';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  imports: [
    MatButtonModule,
    MatExpansionModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    FormsModule,
    MatOptionModule,
    ReactiveFormsModule
  ],
  providers: [provideNativeDateAdapter()],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './toolbar.component.html',
  styleUrl: './toolbar.component.scss'
})
export class ToolbarComponent {  
  @ViewChild(MatAccordion) accordion!: MatAccordion;

  filterForm: FormGroup;

  nameSearch: FormControl<string>;
  role: FormControl<string>;
  status: FormControl<string>;
  startDate: FormControl<Date | null>;
  endDate: FormControl<Date | null>;

  constructor(private fb: FormBuilder) {
    this.nameSearch = new FormControl('', { nonNullable: true });
    this.role = new FormControl('', { nonNullable: true });
    this.status = new FormControl('', { nonNullable: true });
    this.startDate = new FormControl<Date | null>(null);
    this.endDate = new FormControl<Date | null>(null);

    this.filterForm = this.fb.group({
      nameSearch: this.nameSearch,
      role: this.role,
      status: this.status,
      startDate: this.startDate,
      endDate: this.endDate
    });
  }

  applyFilters() {
    const filters = this.filterForm.value;
    console.log('Applying filters:', filters);
    // Here you would typically call a service method to fetch filtered users
    // this.userService.getFilteredUsers(filters).subscribe(users => { ... });
  }
}
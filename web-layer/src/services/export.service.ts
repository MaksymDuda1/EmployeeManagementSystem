import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExportModel } from '../models/export.model';

@Injectable({
  providedIn: 'root'
})
export class ExportService {
  private baseUrl = 'api/admin/export'; 

  constructor(private http: HttpClient) { }

  exportToCsv(users: ExportModel): Observable<Blob> {
    return this.http.post(`${this.baseUrl}/csv`, users, { responseType: 'blob' });
  }
  

  exportToExcel(users: ExportModel): Observable<Blob> {
    return this.http.post(`${this.baseUrl}/excel`,users, { responseType: 'blob' });
  }

  private downloadFile(data: Blob, fileName: string) {
    const blob = new Blob([data], { type: data.type });
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    link.click();
    window.URL.revokeObjectURL(url);
  }

  downloadCsv(users: ExportModel) {
    this.exportToCsv(users).subscribe(
      (data: Blob) => {
        this.downloadFile(data, 'exported_data.csv');
      },
      error => console.error('Error downloading CSV', error)
    );
  }

  downloadExcel(users: ExportModel) {
    this.exportToExcel(users).subscribe(
      (data: Blob) => {
        this.downloadFile(data, 'exported_data.xlsx');
      },
      error => console.error('Error downloading Excel', error)
    );
  }
}
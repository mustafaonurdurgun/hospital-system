import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Appointment } from 'src/core/models/appointment.model';
import { AppointmentRequest } from 'src/core/models/request/appointment-request.model';
import { ResponseStatus } from 'src/core/models/response/base-response.model';
import { User } from 'src/core/models/user.model';
import { ApiService } from 'src/core/services/api/api.service';
import { AuthService } from 'src/core/services/auth/auth.service';

@Component({
  selector: 'app-randevu',
  templateUrl: './randevu.component.html',
  styleUrls: ['./randevu.component.css'],
})
export class RandevuComponent implements OnInit {
  constructor(
    private readonly apiService: ApiService,
    private router: Router,
    private authService:AuthService
  ) {}
currentUser:User|null=null;
  appointments: Appointment[] = [];
  users: User[] = [];
  ngOnInit() {
    this.getAppointments();
    this.apiService.getAllEntities(User).subscribe((response) => {
      this.users = response.data;
      console.log(this.users);
    });
    this.authService.currentUser.subscribe(u=>{
      this.currentUser=u;
    })
  }

  getAppointments() {
    this.apiService.getAllEntities(Appointment).subscribe((response) => {
      this.appointments = response.data;
      console.log(this.appointments);
    });
  }

  // Randevu Silme
  confirmDelete(id: any) {
    const confirmDelete = window.confirm('Silmek istiyor musunuz?');
    if (confirmDelete) {
      let status = this.apiService.deleteEntity(id, Appointment);
      status.then((response) => {
        if (response?.status == ResponseStatus.Ok) {
          window.alert('Randevu silindi!');
          this.getAppointments();
          this.router.navigate(['admin/appointments']);
        } else {
          window.alert('Silme işleminde hata oluştu');
        }
      });
    } else {
      window.alert('Silme işlemi iptal edildi');
    }
  }

  showAddForm = false; // Randevu ekleme formunu göstermek için bir bayrak
  newAppointment: AppointmentRequest = new AppointmentRequest(); 
  addAppointment() {
    // Yeni randevu verilerini API'ye göndermek için bir AppointmentRequest oluşturun
    const appointmentRequest: AppointmentRequest = {
      appointmentDate: this.newAppointment.appointmentDate,
      reason: this.newAppointment.reason,
      userID: this.newAppointment.userID,
      isConfirmed: this.newAppointment.isConfirmed,
    };

    // API'ye yeni randevu ekleyin
    this.apiService
      .createEntity(appointmentRequest, 'Appointment')
      .then((response) => {
        if (response?.status === ResponseStatus.Ok) {
          console.log(status);
          
          window.alert('Randevu başarıyla eklendi!');
          this.getAppointments(); // Randevuları güncelle
          this.cancelAdd(); // Ekleme formunu kapat
        } else {
          window.alert('Randevu eklenirken hata oluştu.');
        }
      })
      .catch((error) => {
        console.error('Hata oluştu:', error);
        window.alert('Randevu eklenirken hata oluştu.');
      });
  }
  // Ekleme formunu kapat
  cancelAdd() {
    this.showAddForm = false;
    this.newAppointment = new Appointment(); // Formu temizle
  }

  // TypeScript dosyanızda
  selectedAppointment: Appointment | null = null;

  showUpdateForm(appointment: Appointment) {
    this.selectedAppointment = appointment;
    // Diğer gerekli işlemleri burada yapabilirsiniz (örneğin, güncelleme formunu göstermek için bir bayrak ayarlamak).
  }

  updateAppointment() {
    if (this.selectedAppointment) {
      // Güncelleme verilerini API'ye gönderin
      this.apiService
        .updateEntity(this.selectedAppointment.id!, this.selectedAppointment, Appointment)
        .then((response) => {
          if (response?.status === ResponseStatus.Ok) {
            window.alert('Randevu başarıyla güncellendi!');
            // Randevuları yeniden getirin veya güncel duruma göre randevuları güncelleyin
            this.getAppointments();
            this.cancelUpdate(); // Güncelleme formunu kapatın
          } else {
            window.alert('Randevu güncellenirken hata oluştu.');
          }
        })
        .catch((error) => {
          console.error('Hata oluştu:', error);
          window.alert('Randevu güncellenirken hata oluştu.');
        });
    }
  }

  cancelUpdate() {
    this.selectedAppointment = null;
  }
  
}

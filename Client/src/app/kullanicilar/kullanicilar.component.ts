import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/core/models/user.model';
import { ApiService } from 'src/core/services/api/api.service';
import { AuthService } from 'src/core/services/auth/auth.service';

@Component({
  selector: 'app-kullanicilar',
  templateUrl: './kullanicilar.component.html',
  styleUrls: ['./kullanicilar.component.css'],
})
export class KullanicilarComponent implements OnInit {
  constructor(
    private readonly apiService: ApiService,
    private router: Router,
    private authService: AuthService
  ) {}
  users: User[] = [];
  currentUser:User|null=null;
  ngOnInit(){
    this.apiService.getAllEntities(User).subscribe((response) => {
      this.users = response.data;
      console.log(this.users);
    });
    this.authService.currentUser.subscribe((user) => {
      this.currentUser = user;      
    });    
  }

}

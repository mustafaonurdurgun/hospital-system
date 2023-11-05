import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginRequest } from 'src/core/models/request/login-request.model';
import { MailRequest } from 'src/core/models/request/mail-request-model';
import { PasswordRequest } from 'src/core/models/request/pw-request-model';
import {
  RegisterRequest,
  UserType,
} from 'src/core/models/request/register-request.model';

import { ResponseStatus } from 'src/core/models/response/base-response.model';
import { User } from 'src/core/models/user.model';
import { ApiService } from 'src/core/services/api/api.service';
import { AuthService } from 'src/core/services/auth/auth.service';

@Component({
  selector: 'app-sign',
  templateUrl: './sign.component.html',
  styleUrls: ['./sign.component.css'],
})
export class SignComponent implements OnInit {
  mail!: MailRequest;
  pw!: PasswordRequest;
  constructor(
    private readonly authService: AuthService,
    private readonly apiService: ApiService,
    private readonly router: Router
  ) {
    this.mail = new MailRequest;
    this.pw = new PasswordRequest;
  }
  ngOnInit() {
    const container = document.getElementById('container');
    const registerBtn = document.getElementById('register');
    const loginBtn = document.getElementById('login');

    if (registerBtn) {
      registerBtn.addEventListener('click', () => {
        container?.classList.add('active');
      });
    }

    if (loginBtn) {
      loginBtn.addEventListener('click', () => {
        container?.classList.remove('active');
      });
    }
  }

  public loginRequest: LoginRequest = <LoginRequest>{};
  public registerRequest: RegisterRequest = <RegisterRequest>{};
  user?: User | null = null;

  async login() {
    try {
      let status = await this.authService.login(this.loginRequest);
      this.authService.currentUser.subscribe((response) => {
        this.user = response;
      });
      await this.router.navigate(['/anasayfa']);
      if (status == ResponseStatus.Invalid) this.loginRequest.Password = '';
    } catch (error) {
      console.log(error);
    }
  }
  userTypes = UserType;
  async register() {
    try {
      // Hata yoksa kayıt işlemi
      const status = await this.authService.register(this.registerRequest);
      console.log(status);
      this.calculateAge();
      if (status === ResponseStatus.Ok) {
        // Başarılı kayıt işlemi
        await this.router.navigate(['']);
        this.registerRequest.Password = '';
        this.registerRequest.LastName = '';
        this.registerRequest.FirstName = '';       
        this.registerRequest.Email = '';       
        
        alert('kayıt başarıyla oluşturuldu')
      } else if (status === ResponseStatus.Invalid) {
        // Geçersiz veri
        this.registerRequest.Password = '';
      }
    } catch (error) {
      // Hata durumunda hata mesajını konsola yazdır
      console.error('Kayıt işlemi sırasında bir hata oluştu: ', error);
    }
  }
  
  calculateAge() {
    if (this.registerRequest.Age) {
      let birthDate = new Date(this.registerRequest.Age);
      let currentDate = new Date();
      let age = currentDate.getFullYear() - birthDate.getFullYear();

      // Doğum günü bu yıl geçtiyse yaşını bir azalt
      if (
        currentDate.getMonth() < birthDate.getMonth() ||
        (currentDate.getMonth() === birthDate.getMonth() &&
          currentDate.getDate() < birthDate.getDate())
      ) {
        age--;
      }

      this.registerRequest.Age = age;
    }
  }


   forgotPw: boolean = false;
  changeCode: string = '';
  mailCheck: boolean = false;
  codeCheck: boolean = false;
  confirm: string = '';
  confirmInput: string = '';

  forgotForm: boolean = false;

  generateConfirmationCode(): string {
    const charset =
      'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    let code = '';

    for (let i = 0; i < 8; i++) {
      const randomIndex = Math.floor(Math.random() * charset.length);
      code += charset.charAt(randomIndex);
    }
    return code.toString();
  }
  codeSenderMail() {
    console.log(this.mail.recepients);
    this.mail!.subject = 'Onay Şifresi';
    this.confirm = this.generateConfirmationCode();
    this.mail!.mail =
      'Merhaba,\n\n' +
      'Hesabınızı onaylamak için aşağıdaki onay kodunu kullanabilirsiniz:\n' +
      this.confirm +
      '\n\n' +
      'Güvenliğiniz için bu kodu kimseyle paylaşmayın. Kodu ilgili alana girerek hesabınızı onaylayabilirsiniz.\n' +
      'Hesabınızın güvende kalması bizim için önemlidir.\n' +
      'Daha fazla yardım veya sorularınız için bize ulaşmaktan çekinmeyin. İyi günler!';
    this.apiService.mailSender(this.mail!).subscribe(
      (response) => {
        console.log('E-posta gönderildi:', response);
        this.mailCheck = true;
      },
      (error) => {
        console.error('E-posta gönderme hatası:', error);
      }
    );
  }
  confirmCodeMethod() {
    if (this.confirm == this.confirmInput) {
      this.mailCheck = false;
      alert('Girdiğiniz Kod Doğru');
      this.codeCheck = true;
    } else {
      alert('Girdiğiniz kod yanlış');
    }
  }
  async changePassword() {
    this.pw!.email = this.mail.recepients?.toString();
    let status = await this.apiService
      .pwChanger(this.pw)
      .then((response) => response?.status);

    if (status == ResponseStatus.Ok) {
      alert('Şifreniz Başarıyla değişti');
    } else {
      alert('Bir hata oluştu');
    }
  }
  openForgotForm() {
    this.forgotPw = true;
    this.mailCheck = false;
  }
  closeForgotForm() {
    this.forgotPw = false;
    this.mailCheck = false;
    this.codeCheck = false;
    this.pw.email = '';
    this.pw.password = '';
    this.mail!.mail = '';
    this.mail!.recepients = '';
    this.mail!.subject = '';
  }
}

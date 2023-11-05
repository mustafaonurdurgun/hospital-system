import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { JwtInterceptor } from 'src/core/services/interceptor/jwt.interceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { SignComponent } from './sign/sign.component';
import { RouterModule } from '@angular/router';
import { ReceteComponent } from './recete/recete.component';
import { RandevuComponent } from './randevu/randevu.component';
import { YorumComponent } from './yorum/yorum.component';
import { AnasayfaComponent } from './anasayfa/anasayfa.component';
import { NavbarComponent } from './navbar/navbar.component';
import { KullanicilarComponent } from './kullanicilar/kullanicilar.component';

@NgModule({
  declarations: [
    AppComponent,
    SignComponent,
    ReceteComponent,
    RandevuComponent,
    YorumComponent,
    AnasayfaComponent,
    NavbarComponent,
    KullanicilarComponent
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,

  ],
  providers: [ { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignComponent } from './sign/sign.component';
import { AnasayfaComponent } from './anasayfa/anasayfa.component';
import { RandevuComponent } from './randevu/randevu.component';
import { ReceteComponent } from './recete/recete.component';
import { KullanicilarComponent } from './kullanicilar/kullanicilar.component';


const routes: Routes = [
  {path:'',component:SignComponent},
  {path:'anasayfa',component:AnasayfaComponent},
  {path:'randevular',component:RandevuComponent},
  {path:'receteler',component:ReceteComponent},
  {path:'kullanıcılar',component:KullanicilarComponent}

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

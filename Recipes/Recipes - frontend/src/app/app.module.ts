import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from 'src/header/header.component';
import { RegisterComponent } from 'src/register/register.component';
import { RecipeComponent } from 'src/recipe/recipe.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {NgIf} from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from 'src/login/login.component';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { AuthInterceptorService } from 'src/services/auth-interceptor.service';
import { CreateRecipeComponent } from 'src/create-recipe/create-recipe.component';
import { DeleteRecipeComponent } from 'src/delete-recipe/delete-recipe.component';
import { RegisterCookComponent } from 'src/register-cook/register-cook.component';
import { CooksComponent } from 'src/cooks/cooks.component';
import { AuthGuardAdminService } from 'src/services/auth-guard-admin.service';
import { AuthGuardCookService } from 'src/services/auth-guard-cook.service';
import { CreateIngredientComponent } from 'src/create-ingredient/create-ingredient.component';
import { IngredientsComponent } from 'src/ingredients/ingredients.component';
import { DeleteIngredientComponent } from 'src/delete-ingredient/delete-ingredient.component';
import {MatListModule} from '@angular/material/list';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import { MatIconModule} from '@angular/material/icon';


const routes: Routes = [
  { path: '', redirectTo: 'recipes', pathMatch: 'full'},
  { path: 'login', component: LoginComponent,  pathMatch: 'full'},
  { path: 'register', component: RegisterComponent,  pathMatch: 'full'},
  { path: 'recipes', component: RecipeComponent, pathMatch: 'full'}, //  canActivate:[AuthGuardService]
  { path: 'create-recipe',component:CreateRecipeComponent, pathMatch:'full', canActivate:[AuthGuardCookService]},
  { path: 'delete-recipe',component:DeleteRecipeComponent, pathMatch:'full', canActivate:[AuthGuardCookService]},
  { path: 'register-cook',component:RegisterCookComponent, pathMatch:'full' , canActivate:[AuthGuardAdminService]},
  { path: 'get-all-cooks',component:CooksComponent, pathMatch:'full' , canActivate:[AuthGuardAdminService]},
  { path: 'create-ingredient',component:CreateIngredientComponent, pathMatch:'full' , canActivate:[AuthGuardAdminService]},
  { path: 'ingredients',component:IngredientsComponent, pathMatch:'full' , canActivate:[AuthGuardAdminService]},
  { path: 'delete-ingredient',component:DeleteIngredientComponent, pathMatch:'full' , canActivate:[AuthGuardAdminService]},
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RegisterComponent,
    LoginComponent,
    RecipeComponent,
    CreateRecipeComponent,
    DeleteRecipeComponent,
    RegisterCookComponent,
    CooksComponent,
    CreateIngredientComponent,
    IngredientsComponent,
    DeleteIngredientComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    MatListModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    NgIf,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

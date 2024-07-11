import { Routes } from '@angular/router';
import { LoginComponent } from './Account components/login/login/login.component';
import { SignUpComponent } from './Account components/login/sign-up/sign-up.component';
import { AddFileComponent } from './File components/add-file/add-file.component';
import { ViewFilesComponent } from './File components/view-files/view-files.component';
import { HomePageComponent } from './Home components/home-page/home-page.component';
import { AddCategoryComponent } from './File components/add-category/add-category.component';



export const routes: Routes = [
    {
        path:'',
        redirectTo:'home',
        pathMatch:'full'
    },   
    {
        path:'home',
        component:HomePageComponent
    },
    {
        path:'login',
        component:LoginComponent
    },
    {
        path:'sign-up',
        component:SignUpComponent
    },
    {
        path:'add-file',
        component:AddFileComponent
    },
    {
        path:'view-files/:userId/:categoryId',
        component:ViewFilesComponent
    },
   
    {
        path:'add-category',
        component:AddCategoryComponent
    },
    
];

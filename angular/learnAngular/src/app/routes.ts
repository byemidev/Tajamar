/* needs to import Rutes from @angular/router and 
the diferent commponents to be able to use 
(for example pages to using navbar from home .. )*/ 

import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DetailsComponent } from './details/details.component';


const routeConfig: Routes = [
    {
      path: '',
      component: HomeComponent,
      title: 'Home page'
    },
    {
      path: 'details/:id', //this dinamyc uri for details: different data for each house.
      component: DetailsComponent,
      title: 'Home details'
    }
  ];
  
  export default routeConfig;
import { RouterLink, RouterOutlet } from '@angular/router'; //necesary to to use the directive:  routerLink 
import { Component, Input } from '@angular/core';
import { Housinglocation } from '../housinglocation';

@Component({
  selector: 'app-housing-location',
  standalone: true,
  imports: [
    RouterLink, 
    RouterOutlet
  ],
  template: `
  <section class="listing">
    <img class="listing-photo" [src]="housingLocation.photo" alt="Exterior photo of {{housingLocation.name}}">
    <h2 class="listing-heading">{{ housingLocation.name }}</h2>
    <p class="listing-location">{{ housingLocation.city}}, {{housingLocation.state }}</p>
    <a class="details" [routerLink]="['/details', housingLocation.id]">Details</a>
  </section>
`,
  styleUrl: './housing-location.component.css'
})

export class HousingLocationComponent {
  @Input() housingLocation!: Housinglocation; // not null or undefined valuer using !
}

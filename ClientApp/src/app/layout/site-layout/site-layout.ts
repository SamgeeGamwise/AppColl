import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from '../../shared/navbar/navbar';

@Component({
  selector: 'app-site-layout',
  imports: [
    Navbar,
    RouterOutlet
  ],
  templateUrl: './site-layout.html',
  styleUrl: './site-layout.scss'
})
export class SiteLayout {}

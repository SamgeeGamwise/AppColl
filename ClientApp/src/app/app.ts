import {Component, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {SiteLayout} from './layout/site-layout/site-layout';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SiteLayout],
  templateUrl: './app.html',
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class App {}

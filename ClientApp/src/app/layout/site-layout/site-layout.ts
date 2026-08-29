import {
  ChangeDetectionStrategy,
  Component
} from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { Navbar } from '../../shared/components/navbar/navbar';

@Component({
  selector: 'app-site-layout',
  standalone: true,
  imports: [
    RouterOutlet,
    Navbar
  ],
  templateUrl: './site-layout.html',
  styleUrl: './site-layout.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SiteLayout {}

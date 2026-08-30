import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-alert',
  standalone: true,
  templateUrl: './alert.component.html',
  styleUrl: './alert.component.scss',
})
export class AlertComponent {
  @Input() message = 'Loading...';
}

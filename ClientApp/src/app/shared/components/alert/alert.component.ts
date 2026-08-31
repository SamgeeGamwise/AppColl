import {Component, inject, Input} from '@angular/core';
import {BroadbandStore} from '@broadband/state/broadband.store';

@Component({
  selector: 'app-alert-component',
  standalone: true,
  templateUrl: './alert.component.html',
  styleUrl: './alert.component.scss',
})
export class AlertComponent {
  protected readonly broadbandStore = inject(BroadbandStore);
}

import {
  ChangeDetectionStrategy,
  Component,
  input
} from '@angular/core';
import {RouterLink, RouterLinkActive} from '@angular/router';
import {NgClass} from '@angular/common';

@Component({
  selector: 'app-broadband-tabs',
  standalone: true,
  templateUrl: './broadband-tabs.html',
  imports: [
    RouterLink,
    RouterLinkActive,
    NgClass
  ],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BroadbandTabs {
  readonly tabs = [
    { label: 'Records', route: '/records' },
    { label: 'Summary', route: '/records/summary' }
  ];

}

import {
  ChangeDetectionStrategy,
  Component, CUSTOM_ELEMENTS_SCHEMA,
  input
} from '@angular/core';

@Component({
  selector: 'app-filters-input-component',
  templateUrl: './filters-input-component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class FiltersInputComponent {
  readonly id = input.required<string>()
  readonly name = input.required<string>()
  readonly type = input<'number' | 'text'>('number');
}

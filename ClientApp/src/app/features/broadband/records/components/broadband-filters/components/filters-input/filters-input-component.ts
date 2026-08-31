import {
  ChangeDetectionStrategy,
  Component, CUSTOM_ELEMENTS_SCHEMA,
  input
} from '@angular/core';
import {FormControl, ReactiveFormsModule} from '@angular/forms';

@Component({
  selector: 'app-filters-input-component',
  templateUrl: './filters-input-component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    ReactiveFormsModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class FiltersInputComponent {
  readonly id = input.required<string>()
  readonly name = input.required<string>()
  readonly type = input<'number' | 'text'>('number');

  readonly control = input.required<FormControl>();
}

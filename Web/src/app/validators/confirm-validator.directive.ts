import { Directive, Input } from '@angular/core';
import { NG_VALIDATORS, Validator, AbstractControl } from '@angular/forms';

@Directive({
  selector: '[appConfirms]',
  providers: [{provide: NG_VALIDATORS, useExisting: ConfirmValidatorDirective, multi: true}]
})
export class ConfirmValidatorDirective implements Validator {
  @Input()
  public appConfirms: AbstractControl;

  public validate(control: AbstractControl): {[key: string]: any} | null {
    if (this.appConfirms == null || control == null) {
      return null;
    }

    if (control.value !== this.appConfirms.value) {
      return {'appConfirms': {value: control.value}};
    }

    return null;
  }
}

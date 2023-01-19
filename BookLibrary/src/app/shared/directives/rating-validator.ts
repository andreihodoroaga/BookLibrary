import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function forbiddenRating(nameRe: RegExp): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const forbidden = nameRe.test(control.value);
    return !forbidden ? {forbiddenRating: true} : null;
  };
}
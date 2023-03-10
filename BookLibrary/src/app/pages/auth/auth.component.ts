import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  /**
   * Is true if the user is logged in.
   */
  isLoginMode = true;

  /**
   * Is true if sign up / log in is currently sending a request.
   */
  isLoading = false;

  /**
   * Error message
   */
  error: string = '';

  /**
   * Reactive form for authentication.
   */
  form: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(5)]]
    });
  }

  ngOnInit(): void {
  }

  onSwitchMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  onSubmit() {
    if (!this.form.valid)
      return;

    const email = this.form.value.email;
    const password = this.form.value.email;
    this.isLoading = true;

    if (this.isLoginMode) {
      this.authService.login(email, password).subscribe((response) => {
        this.isLoading = false;
        this.router.navigate(['/books']);
      }, error => {
        this.error = error;
        this.isLoading = false;
      })
    } else {
      this.authService.signup(email, password).subscribe((response) => {
        console.log('Sign up successful!');
        this.isLoading = false;
      });
    }
    
    this.form.reset();
  }

}

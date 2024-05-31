import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { LoginService } from '../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  form: FormGroup | undefined;
  error: boolean = false;

  constructor(private loginService: LoginService, private router: Router) {
  }

  ngOnInit(): void {
    this.form = new FormGroup<any>({
      email: new FormControl(''),
      password: new FormControl('')
    });
  }

  login(): void {
    const formValue = this.form?.value;
    this.loginService
      .login({ email: formValue.email, password: formValue.password })
      .subscribe({
        next: result => {
          this.loginService.saveToken(result.token);
          this.router.navigate(['/home']);
        },
        error: _ => {
          this.error = true;
        }
      });
  }
}

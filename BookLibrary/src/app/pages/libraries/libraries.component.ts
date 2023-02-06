import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LibrariesService } from 'src/app/core/services/libraries.service';
import { Library } from 'src/app/shared/models/library.model';

@Component({
  selector: 'app-libraries',
  templateUrl: './libraries.component.html',
  styleUrls: ['./libraries.component.scss'],
})
export class LibrariesComponent implements OnInit {
  /**
   * Array containing all libraries.
   */
  libraries!: Library[];

  /**
   * The page url.
   */
  url: string = '';

  constructor(
    private readonly librariesService: LibrariesService,
    private readonly router: Router,
    private readonly route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.getLibraries();
    this.url = this.router.url;
  }

  getLibraries() {
    this.librariesService.getLibraries().subscribe((responseLibraries) => {
      this.libraries = responseLibraries;
    });
  }

  // navigateToLibrary(libraryId: string) {
  //   this.router.navigate([this.url + "/" + libraryId]);
  // }
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Library } from '../../models/library.model';
import { LibrariesService } from 'src/app/core/services/libraries.service';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.scss']
})
export class LibraryComponent implements OnInit {
  libraryId?: string | null;
  library!: Library;

  constructor(private route: ActivatedRoute, private readonly librariesService: LibrariesService) {}

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.libraryId = params.get('id');
      if(this.libraryId)
        this.getLibraryById(this.libraryId);
    });
  }

  getLibraryById(libraryId: string) {
    this.librariesService.getById(libraryId).subscribe(library => {
      this.library = library;
    })
  }
}

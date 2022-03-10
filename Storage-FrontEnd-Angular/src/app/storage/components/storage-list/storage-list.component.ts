import { Component, OnInit } from '@angular/core';
import { ResultItem } from '../../models/resultItem';
import { StorageService } from '../../services/storage.service';

@Component({
  selector: 'app-storage-list',
  templateUrl: './storage-list.component.html',
  styleUrls: ['./storage-list.component.css'],
})
export class StorageListComponent implements OnInit {

  storageItems: ResultItem[] = [];

  constructor(private storageService: StorageService) {

  }

  ngOnInit(): void {
    this.storageService.getItems()
      .then(items => this.storageItems = items);
  }

}

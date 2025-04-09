import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonApiService, CommonService } from 'src/app/services';


@Component({
  selector: 'app-gadget-list',
  templateUrl: './gadget-list.component.html',
  styleUrls: ['./gadget-list.component.css']
})
export class GadgetListComponent {
  gadgets: any[] = [];
  selectedGadgets: number[] = [];
  currentPage = 1;
  itemsPerPage = 5;
  showAddModal = false;
  editGadgetId!: number;
  constructor(private router: Router,
    private commonApiService: CommonApiService,
    private commonService: CommonService
  ) { }

  ngOnInit() {
    this.getGadgets();
  }

  getGadgets() {
    this.showAddModal = false;
    this.commonApiService.getRequest("Gadget/GetGadget").subscribe((res) => {
      if (res) {
        this.gadgets = res.data.result;
        this.editGadgetId = 0;
      }
    })
  }


  get pagedGadgets() {
    const start = (this.currentPage - 1) * this.itemsPerPage;
    return this.gadgets.slice(start, start + this.itemsPerPage);
  }

  get totalPages() {
    return Math.ceil(this.gadgets.length / this.itemsPerPage);
  }

  nextPage() {
    if (this.currentPage < this.totalPages) this.currentPage++;
  }

  prevPage() {
    if (this.currentPage > 1) this.currentPage--;
  }

  toggleSelection(id: number) {
    if (this.selectedGadgets.includes(id)) {
      this.selectedGadgets = this.selectedGadgets.filter(i => i !== id);
    } else {
      this.selectedGadgets.push(id);
    }
  }

  toggleAll(event: any) {
    if (event.target.checked) {
      this.selectedGadgets = this.pagedGadgets.map(g => g.id);
    } else {
      this.selectedGadgets = [];
    }
  }

  allSelected() {
    return this.pagedGadgets.every(g => this.selectedGadgets.includes(g.id));
  }


  editGadget(gadget: any) {
    this.editGadgetId = gadget.id;
    this.showAddModal = true;
  }

  deleteGadget(id: any) {
    this.commonApiService.deleteRequest("Gadget/DeleteGadget/" + id).subscribe((res) => {
      if (res) {
        this.getGadgets();
      }
    })
  }
  deleteSelected() {
    this.deleteGadget(this.selectedGadgets.join(','))
  }
  viewDetails(id: number) {
    this.router.navigateByUrl ('/gadget/' + this.commonService.encrypt(id.toString()));
  }
}


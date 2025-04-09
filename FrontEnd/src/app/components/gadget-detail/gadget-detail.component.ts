import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonApiService, CommonService } from 'src/app/services';

@Component({
  selector: 'app-gadget-detail',
  templateUrl: './gadget-detail.component.html',
})
export class GadgetDetailComponent implements OnInit {
  gadget: any;
  id!: number;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private commonService: CommonService,
    private commonApiService: CommonApiService) { }

  ngOnInit() {
    this.id = +this.route.snapshot.paramMap.get('id')!;
    this.getGadgetById();
  }

  getGadgetById() {
    if (this.id != null) {
      this.commonApiService.getRequest("Gadget/GetGadgetById/" + this.commonService.decrypt(this.route.snapshot.paramMap.get('id'))).subscribe((res) => {
        if (res) {
          this.gadget = res.data
        }
      })
    }
  }

  backToList() {
    this.router.navigate(['/gadgets']);
  }
}

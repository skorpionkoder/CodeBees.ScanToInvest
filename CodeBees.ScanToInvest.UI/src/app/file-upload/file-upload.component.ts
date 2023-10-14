import { Component, OnInit } from '@angular/core';
import { FileUploadService } from '../file-upload.service';
import { VisionService } from '../vision.service';
import { StocksDetailService } from '../stocks-detail.service';
import { StockDetailResponse } from 'src/stock';

@Component({
	selector: 'app-file-upload',
	templateUrl: './file-upload.component.html',
	styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent implements OnInit {

	// Variable to store shortLink from api response
	shortLink: string = "";
	loading: boolean = false; // Flag variable
	file: File |any= null; // Variable to store file

  // Variables for API response
  blobUrl: any = "";
  visionObj: any = "";
  stockCode: any = "";
  stockDetails: any = "";
  similarStocks: any = "";

	// Inject service
	constructor(private fileUploadService: FileUploadService, private visionService: VisionService, private stocksService: StocksDetailService) { }

	ngOnInit(): void {
	}

	// On file Select
	onChange(event:any) {
		this.file = event.target.files[0];
	}

	// OnClick of button Upload
	onUpload() {
		this.loading = !this.loading;
		console.log(this.file);
		this.fileUploadService.upload(this.file).subscribe(
      response => {
        this.blobUrl = response;
        this.visionService.getVisionObject(this.blobUrl).subscribe(
          vision => {
            this.visionObj = vision
            this.stocksService.getStocks(this.visionObj).subscribe(
              stock => {
                this.stockCode = stock
                this.stocksService.getStockDetails(this.stockCode).subscribe(
                  stockDetail => {
                    this.stockDetails = stockDetail
                    this.stocksService.getSimilarStockDetails(this.stockDetails.results.description).subscribe(
                      similarStocks => this.similarStocks = similarStocks
                    )
                  }
                )
              }
            )
          }
        );
      }
		);
    this.loading = false; // Flag variable
	}

}

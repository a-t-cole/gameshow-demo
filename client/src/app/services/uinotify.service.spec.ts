import { TestBed } from '@angular/core/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule, ToastrService } from 'ngx-toastr';

import { UINotifyService } from './uinotify.service';

describe('UIErrorHandlerService', () => {
  let service: UINotifyService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        BrowserAnimationsModule, 
        ToastrModule.forRoot()
      ]
    });
    service = TestBed.inject(UINotifyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should error', () => {
    let result = service.throwError('tadaa!')
    expect(result).toBeTruthy(); 

    result = service.throwError(''); 
    expect(result).toBeNull(); 
  });
  it('should info', () => {
    let result = service.toastInfo('tadaa!')
    expect(result).toBeTruthy(); 

    result = service.toastInfo(''); 
    expect(result).toBeNull(); 
  });
  it('should error', () => {
    let result = service.throwSuccess('tadaa!')
    expect(result).toBeTruthy(); 

    result = service.throwSuccess(''); 
    expect(result).toBeNull(); 
  });
});

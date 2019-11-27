import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { FormsModule } from '@angular/forms';
import { CreateTrainingComponent } from './create-training.component';
import { HttpClient } from '@angular/common/http';

describe('ResetPasswordEmailCollection', () => {

    let component: CreateTrainingComponent;
    let fixture: ComponentFixture<CreateTrainingComponent>;
    let mockedHttpClient: any;

    beforeEach(async(() => {

        TestBed.configureTestingModule({
            declarations: [
                CreateTrainingComponent
            ],
            imports: [
                RouterTestingModule,
                FormsModule,
            ],
            providers: [
                { provide: HttpClient, useValue: mockedHttpClient },
                {
                    provide: 'BASE_URL',
                    useValue: ""
                }
            ]
        })
            .compileComponents();
    }));

    beforeEach(() => {

        fixture = TestBed.createComponent(CreateTrainingComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should contain NameLabel control with correct text', async(() => {
        const control = fixture.nativeElement.querySelector('#NameLabel');
        expect(control).not.toBeNull();
        expect(control.innerText).toEqual("Training Name");
    }));

    it('should contain Name control with empty value by default', async(() => {
        const control = fixture.nativeElement.querySelector('#Name');
        expect(control).not.toBeNull();
        expect(control.value).toEqual("");
    }));

    it('should show Form by default', async(() => {
        const control = fixture.nativeElement.querySelector('#FormContainer');
        expect(control).not.toBeNull();
    }));

    it('should hide Form if Loading', async(() => {
        component.Loading = true;
        fixture.detectChanges();
        fixture.whenStable().then(() => {
            const control = fixture.nativeElement.querySelector('#FormContainer');
            expect(control).toBeNull();
        });
    }));

    it('should hide Form if Success is true', async(() => {
        component.Success = true;
        fixture.detectChanges();
        fixture.whenStable().then(() => {
            const control = fixture.nativeElement.querySelector('#FormContainer');
            expect(control).toBeNull();
        });
    }));
});

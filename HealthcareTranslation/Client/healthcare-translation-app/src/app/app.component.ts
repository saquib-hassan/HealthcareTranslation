import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TranslationService } from './translation.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.component.html',
  providers: [TranslationService],
})
export class AppComponent {
  sourceLang = 'en';
  targetLang = 'es';
  transcript = '';
  translatedText = '';

  constructor(private translationService: TranslationService) {}

  async startRecording() {
    const recognition = new (window as any).webkitSpeechRecognition();
    recognition.lang = this.sourceLang;
    recognition.start();

    recognition.onresult = async (event: any) => {
      this.transcript = event.results[0][0].transcript;
    };
  }

  async translate() {
    this.translatedText = await this.translationService.translateText(
      this.transcript,
      this.sourceLang,
      this.targetLang
    );
  }

  speak() {
    const speech = new SpeechSynthesisUtterance(this.translatedText);
    speech.lang = this.targetLang;
    window.speechSynthesis.speak(speech);
  }
}

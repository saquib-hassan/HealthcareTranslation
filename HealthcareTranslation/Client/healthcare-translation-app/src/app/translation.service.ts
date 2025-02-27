import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class TranslationService {
  private apiUrl = 'https://localhost:7241/api/Translation/translate';

  async speechToText(audioBase64: string, language: string): Promise<string> {
    const response = await axios.post(`${this.apiUrl}/speech-to-text`, {
      audioBase64,
      language,
    });
    return response.data;
  }

  async translateText(
    text: string,
    sourceLang: string,
    targetLang: string
  ): Promise<string> {
    const response = await axios.post(`${this.apiUrl}/translate`, {
      text,
      sourceLang,
      targetLang,
    });
    return response.data.TranslatedText;
  }
}

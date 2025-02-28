Healthcare Translation App Documentation
Prototype Link
•	Live Prototype: [Insert your Koyeb deployment link here]
Code Documentation
Code Structure
•	Frontend (Angular):
o	Template (HTML):
Renders the title, language selector, and buttons to start recording, translate text, and speak the translation.
o	Component (TypeScript):
	Uses webkitSpeechRecognition to capture audio.
	Calls the translation service to process the transcript.
	Uses browser speech synthesis for audio playback.
o	Testing:
Basic unit tests verify component creation and UI elements.
•	Backend (ASP.NET Core):
o	Controllers:
	TranslationController:
Exposes endpoints for:
	/api/Translation/speech-to-text: Uses Google Speech API to convert audio (base64) into text.
	/api/Translation/translate: Utilizes OpenAI’s GPT-3.5-turbo model for text translation.
o	Services:
The TranslationService encapsulates API calls (using Axios) to the speech-to-text and translation endpoints.
o	Configuration & Middleware:
	Configured CORS to allow requests from specific origins.
	Serves static files and provides API documentation via Swagger.
	Environment files differentiate local development from production.
AI Tools Used
•	Google Speech API:
Converts audio input into text.
•	OpenAI API:
Leverages the gpt-3.5-turbo model to translate text.

Security Considerations
•	CORS Policy:
Limits access to specified origins
•	API Key Management:
API keys are currently hard-coded; it is recommended to manage them securely using environment variables or a secrets manager in production.
•	HTTPS & Input Validation:
HTTPS redirection is enabled to secure data in transit. Additional input sanitization is advised.
Deployment
•	Dockerized Architecture:
Both the frontend and backend have been containerized using Docker, ensuring consistency across environments.
•	Koyeb Deployment:
The application is deployed on Koyeb, providing scalable, container-based hosting for production.
User Guide
1.	Select Language:
Use the dropdown menu to choose the desired source language (English, Spanish, or French).
2.	Start Recording:
Click Start Speaking to record your voice. The app converts your speech into text and displays it.
3.	Translate:
Click Translate to convert the transcript into the target language.
4.	Listen to Translation:
Click Speak Translation to hear the translated text via the browser’s speech synthesis.


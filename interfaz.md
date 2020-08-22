# Definición de la interfaz de la API

## Obtener un Examen

### Endpoint

- PATH: /exams/{id}
- Método HTTP: GET

### Ejemplo Body Request

No recibe Body Request

### Ejemplo Body Response
```
{
	"id": 1,
	"title": "Evaluación Full Stack Developer",
	"description": "En esta evaluación buscamos evaluar tu seniority",
	"questions": 
	[
	  	{
			"id": 1,
			"questionText": "Verdadero o Falso: HTML es un lenguaje de programación",
			"correctAnswer": "Falso"
		},
		{
			"id": 2,
			"questionText": "Cuál de las siguientes palabras, no es una palabra reservada de ANSI-SQL?",
			"correctAnswer": "OVER",
			"option1": "DISTINCT",
			"option2": "OVER",
			"option3": "FROM"
		},
		{
			"id": 3,
			"questionText": "Cuál es el comparador que se usa en Python cuando queremos saber si la referencia de dos variables es el mismo objeto",
			"correctAnswer": "is"
		}
	]
}
```
### Códigos de Respuesta HTTP

#### 200: OK
En caso de procesamiento exitoso, devolviendo el Body Response

#### 400: Bad Request
En caso de ser incorrecta la sintaxis del Request

#### 404: Not Found
En caso de no existir un examen con el ID especificado

#### 500: Internal Server Error
En caso de ocurrir un error en el servidor 

## Enviar respuestas y ver puntaje

### Endpoint

- PATH: /users/{userId}/exams/{examId}/solve
- Método HTTP: POST

### Ejemplo Body Request
```
{
	"answers": 
	[
		{
			"questionId": 1,
			"enteredAnswer": "False"
		},
		{
			"questionId": 2,
			"enteredAnswer": "OVER"
		},
		{
			"questionId": 3,
			"enteredAnswer": "is"
		}
	]
}
```
### Ejemplo Body Response
```
{
	"score": 8
}
```
### Códigos de Respuesta HTTP

#### 200: OK
En caso de procesamiento exitoso, devolviendo el Body Response

#### 400: Bad Request
En caso de ser incorrecta la sintaxis del Request

#### 404: Not Found
En caso de no existir un usuario o un examen con los IDs especificados

#### 500: Internal Server Error
En caso de ocurrir un error en el servidor 

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

export interface ValueAndReferenceType {
  refName: string;
  value: number,
  refArray: number[]
}

export interface PassingParams {
  value: number,
  reference: number,
  outValue: number,
  parameters: number[]
}

export interface ClassObject {
  intProperty: number,
  stringProperty: string,
  forExample: ForExample
}

export interface ForExample {
  name: string,
  randomNumber: number
}

export interface Growth {
  chapter: string,
  lessons: Lesson[]
}

export interface Phase {
  phaseName: string,
  growthArray: Growth[]
}

export interface Lesson {
  name: string,
  link: string
}

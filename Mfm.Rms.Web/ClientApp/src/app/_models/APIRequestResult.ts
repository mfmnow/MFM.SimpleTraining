export interface APIRequestResult {
  success: boolean;
  message: string;
  data: any;
  serverError: boolean;
  errorMessage: string;
}

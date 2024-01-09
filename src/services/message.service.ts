import axios, { AxiosRequestConfig } from 'axios';

// Define the interface for your API response
interface ApiResponse<T = any> {
  data: T | null;
  error: string | null;
}

// API base URL
const API_BASE_URL = "http://localhost:5001";

// Function to fetch public resources
export const getPublicResource = async (): Promise<ApiResponse> => {
  try {
    const config: AxiosRequestConfig = {
      url: `${API_BASE_URL}/api/messages/public`, // Modify with actual endpoint
      method: 'GET',
    };

    const response = await axios(config);
    return { data: response.data, error: null };
  } catch (error) {
    return handleError(error);
  }
};

// Function to fetch protected resources
export const getProtectedResource = async (accessToken: string): Promise<ApiResponse> => {
  try {
    const config: AxiosRequestConfig = {
      url: `${API_BASE_URL}/api/messages/protected`, // Modify with actual endpoint
      method: 'GET',
      headers: {
        'Authorization': `Bearer ${accessToken}`,
      },
    };

    const response = await axios(config);
    return { data: response.data, error: null };
  } catch (error) {
    return handleError(error);
  }
};

// General error handling function
function handleError(error: any): ApiResponse {
  if (axios.isAxiosError(error)) {
    return {
      data: null,
      error: error.response?.statusText || 'An unknown error occurred',
    };
  }
  return {
    data: null,
    error: 'An unknown error occurred',
  };
}

export const getAdminResource = async (accessToken: string): Promise<ApiResponse> => {
  try {
    const config: AxiosRequestConfig = {
      url: `${API_BASE_URL}/api/messages/admin`, // Modify with the actual endpoint
      method: 'GET',
      headers: {
        'Authorization': `Bearer ${accessToken}`,
      },
    };

    const response = await axios(config);
    return { data: response.data, error: null };
  } catch (error) {
    return handleError(error);
  }
};
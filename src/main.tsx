import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import { Auth0ProviderWithNavigate } from './auth0-provider-with-navigate.tsx';
import { BrowserRouter } from 'react-router-dom';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <BrowserRouter> // Компонент для маршрутизації
      <Auth0ProviderWithNavigate> // Компонент для аутентифікації з Auth0
        <App /> // Основний компонент додатку
      </Auth0ProviderWithNavigate>
    </BrowserRouter>
  </React.StrictMode>,
)

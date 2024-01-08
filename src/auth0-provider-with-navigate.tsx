import { Auth0Provider, AppState } from "@auth0/auth0-react";
import React, { PropsWithChildren } from "react";
import { useNavigate } from "react-router-dom";

// Оголошення інтерфейсу для пропсів компонента Auth0ProviderWithNavigate
interface Auth0ProviderWithNavigateProps {
  children: React.ReactNode; // визначення дітей компонента як ReactNode
}

// Експорт компонента Auth0ProviderWithNavigate
export const Auth0ProviderWithNavigate = ({
  children,
}: PropsWithChildren<Auth0ProviderWithNavigateProps>): JSX.Element | null => {
  const navigate = useNavigate(); // Використання хука для навігації

  // Отримання налаштувань Auth0 з змінних середовища
  const domain = "dev-testguru.eu.auth0.com";
  const clientId = "PXaefUnOAB13yhQ7piZXM1Tel5vblnzc";
  const redirectUri = "http://localhost:5173";

  // Функція зворотнього виклику для обробки редиректу після аутентифікації
  const onRedirectCallback = (appState?: AppState) => {
    navigate(appState?.returnTo || window.location.pathname);
  };

  // Перевірка чи всі необхідні налаштування є наявними
  if (!(domain && clientId && redirectUri)) {
    return null; // якщо налаштувань немає, повертаємо null
  }

  // Повернення компонента Auth0Provider з переданими параметрами
  return (
    <Auth0Provider
      domain={domain}
      clientId={clientId}
      authorizationParams={{
        redirect_uri: redirectUri,
      }}
      onRedirectCallback={onRedirectCallback}
    >
      {children} // Вставка дочірніх компонентів
    </Auth0Provider>
  );
};

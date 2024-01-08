import { withAuthenticationRequired } from "@auth0/auth0-react";
import React, { ComponentType } from "react";
import { PageLoader } from "./page-loader";

// Оголошення інтерфейсу для пропсів AuthenticationGuard
interface AuthenticationGuardProps {
  component: ComponentType; // Вказує, що пропс component має бути React компонентом
}

// Оголошення компонента AuthenticationGuard, який використовується для захисту маршрутів
export const AuthenticationGuard: React.FC<AuthenticationGuardProps> = ({
  component, // Деструктуризація пропса component
}) => {
  // Створення захищеного компонента з використанням withAuthenticationRequired
  const Component = withAuthenticationRequired(component, {
    // Функція onRedirecting визначає, що відображати під час перенаправлення на аутентифікацію
    onRedirecting: () => (
      <div className="page-layout"> // Блок з класом page-layout
        <PageLoader /> // Компонент PageLoader показується під час перенаправлення
      </div>
    ),
  });

  // Рендеринг захищеного компонента
  return <Component />;
};
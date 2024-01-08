import React from 'react';
import { useAuth0 } from "@auth0/auth0-react";
import { HiArrowLeftOnRectangle } from "react-icons/hi2";
import Button from '../../ui/Button'; 

export const LoginButton: React.FC = () => {
  const { loginWithRedirect, isAuthenticated, user, isLoading } = useAuth0();
  console.log({isAuthenticated, user, isLoading });

  const handleLogin = async () => {
    await loginWithRedirect({
      appState: {
        returnTo: "/users",
      },
      authorizationParams: {
        prompt: "login",
      },
    });
  };

  return (
    <Button onClick={handleLogin} size="medium" variation="linkLike">
        <HiArrowLeftOnRectangle  />
        Log In
      </Button>
  );
};

export default LoginButton;

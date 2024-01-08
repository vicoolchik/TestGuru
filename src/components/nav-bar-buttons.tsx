import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import { SignupButton } from "./buttons/signup-button";
import { LoginButton } from "./buttons/login-button";
import { LogoutButton } from "./buttons/logout-button";


export const NavBarButtons: React.FC = () => {
  const { isAuthenticated, user, isLoading } = useAuth0();
  console.log({isAuthenticated, user, isLoading });
  return (
    <div className="nav-bar__buttons">
      {!isAuthenticated && (
        <>
          <SignupButton />
          <LoginButton />
        </>
      )}
      {isAuthenticated && (
        <>
          <LogoutButton />
        </>
      )}
    </div>
  );
};

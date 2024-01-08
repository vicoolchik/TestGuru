import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import Button from "../../ui/Button";

export const SignupButton: React.FC = () => {
  const { loginWithRedirect } = useAuth0();

  const handleSignUp = async () => {
    await loginWithRedirect({
      appState: {
        returnTo: "/users",
      },
      authorizationParams: {
        prompt: "login",
        screen_hint: "signup",
      },
    });
  };

  return (
    <Button onClick={handleSignUp} size="medium" variation="linkLike">
      Sign Up
    </Button>
  );
};

import { useAuth0 } from "@auth0/auth0-react";
import React from "react";
import Button from "../../ui/Button";
import { HiArrowRightOnRectangle } from "react-icons/hi2";

export const LogoutButton: React.FC = () => {
  const { logout } = useAuth0();

  const handleLogout = () => {
    logout({
      logoutParams: {
        returnTo: window.location.origin,
      },
    });
  };

  return (
    <Button onClick={handleLogout} size="medium" variation="linkLike">
        <HiArrowRightOnRectangle />
        Log Out
    </Button>
  );
};

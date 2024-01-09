import React, { useEffect, useState } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { getProtectedResource } from "../services/message.service";

export const ProtectedPage: React.FC = () => {
  const [message, setMessage] = useState<string>("");
  const { getAccessTokenSilently,user, isAuthenticated, isLoading, getIdTokenClaims } = useAuth0();
  

  useEffect(() => {
    let isMounted = true;

    const getMessage = async () => {
      try {
        const accessToken = await getAccessTokenSilently();
        const idToken = await getIdTokenClaims();
        console.log(accessToken);
        console.log(idToken);
        const { data, error } = await getProtectedResource(accessToken);

        if (!isMounted) {
          return;
        }

        if (data) {
          setMessage(JSON.stringify(data, null, 2));
        } else if (error) {
          setMessage(JSON.stringify(error, null, 2));
        }
      } catch (e: unknown) { // Note: TypeScript treats errors as 'unknown' type
        if (e instanceof Error) {
          setMessage("Error fetching protected resource: " + e.message);
        } else {
          setMessage("An unknown error occurred.");
        }
      }
    };
    console.log({isAuthenticated, user, isLoading});
    getMessage();

    return () => {
      isMounted = false;
    };
  }, [getAccessTokenSilently]);

  return (
      <div className="content-layout">
        <h1 id="page-title" className="content__title">
          Protected Page
        </h1>
        <div className="content__body">
          <p id="page-description">
            This page retrieves a <strong>protected message</strong> from an external API. Only authenticated users can access this page.
          </p>
          <h1 title={message} />
        </div>
      </div>

  );
};

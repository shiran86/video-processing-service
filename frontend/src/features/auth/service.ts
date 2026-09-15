import type { CurrentUser } from "./types";

export const login = () => {
    window.location.href = "https://localhost:7105/auth/login";
};

export const logout = () => {
    window.location.href = "https://localhost:7105/auth/logout";
};

export const getCurrentUser = async (): Promise<CurrentUser | null> => {
    try {
        const response = await fetch("https://localhost:7105/auth/me", {
            credentials: "include"
        });

        if (response.status === 401) {
            return null;
        }

        if (!response.ok) {
            throw new Error("Failed to get current user");
        }

        return response.json();
    }
    catch (error) {
        throw new Error("Failed to get current user", {
            cause: error
        });
    }



};
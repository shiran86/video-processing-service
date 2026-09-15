import { logout } from "../service";

export function LogoutButton() {
    return (
        <button onClick={logout}>
            Logout
        </button>
    );
}
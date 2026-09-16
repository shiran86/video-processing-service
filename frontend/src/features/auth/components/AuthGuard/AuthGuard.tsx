import { useCurrentUser } from '../../useCurrentUser'
import type { AuthGuardProps } from './types'

export const AuthGuard = ({ children, fallback }: AuthGuardProps) => {
  const { data: currentUser, isLoading, isError } = useCurrentUser()

  if (isLoading) {
    return <div>Loading...</div>
  }

  if (isError) {
    return <div>Something went wrong</div>
  }

  if (!currentUser) {
    return fallback
  }
  return children
}

import { API_BASE_URL } from '../../config'
import type { Video } from './components/videoView/types'

export const getVideo = async (id: number): Promise<Video> => {
  const response = await fetch(`${API_BASE_URL}/videos/${id}`, { credentials: 'include' })

  if (!response.ok) {
    throw new Error(`Request failed with status ${response.status}`)
  }

  return response.json() as Promise<Video>
}

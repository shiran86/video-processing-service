import type { Video } from './types'

export const getVideo = async (): Promise<Video> => {
  const response = await fetch('https://localhost:7105/api/v1/videos/123')
  const data: { result: Video } = await response.json()

  return data.result
}

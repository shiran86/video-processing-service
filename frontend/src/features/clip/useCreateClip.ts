import { useMutation } from '@tanstack/react-query'
import { createClip } from './service'
import type { CreateClipRequest } from './types'

export const useCreateClip = () => {
  return useMutation({
    mutationFn: ({
      videoId,
      request,
    }: {
      videoId: number
      request: CreateClipRequest
    }) => createClip(videoId, request),
  })
}
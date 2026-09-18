import { useQuery } from '@tanstack/react-query'
import { getVideo } from './service'
import { videoQueryKeys } from './queryKeys'

export const useVideo = (id: number) => {
  return useQuery({
    queryKey: videoQueryKeys.byId(id),
    queryFn: () => getVideo(id),
  })
}

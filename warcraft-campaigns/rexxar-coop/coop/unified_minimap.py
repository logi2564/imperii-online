"""Place the original detailed minimaps at the atlas' real terrain positions."""
import io
from PIL import Image
from unified_terrain import SIZE


def render(terrains, maps, size=256):
    # Use the native classic minimap dimensions; only resample the supplied
    # terrain thumbnails. No unrelated art or invented rectangular markers.
    atlas = Image.new('RGB', (size, size), (13, 18, 24))
    for terrain in terrains:
        data = maps[terrain.name]['data']['war3mapMap.blp']
        if not data:
            raise ValueError('Missing original minimap: ' + terrain.name)
        source = Image.open(io.BytesIO(data)).convert('RGB')
        left, bottom, width, height = terrain.crop
        cols, rows = terrain.width - 1, terrain.height - 1
        crop = (left * source.width / cols,
                (rows - bottom - height) * source.height / rows,
                (left + width) * source.width / cols,
                (rows - bottom) * source.height / rows)
        rect = (round(terrain.atlas_x * size / SIZE),
                round((SIZE - terrain.atlas_y - height) * size / SIZE),
                round((terrain.atlas_x + width) * size / SIZE),
                round((SIZE - terrain.atlas_y) * size / SIZE))
        patch = source.crop(crop).resize((rect[2] - rect[0], rect[3] - rect[1]), Image.Resampling.LANCZOS)
        atlas.paste(patch, rect[:2])
    result = io.BytesIO()
    atlas.save(result, format='TGA')
    return result.getvalue()
